'use strict';

let panicElement;
let rawPanicMessages = [];
const Messages = [];

// Panic overlay creation and display
function showPanicElementIfNeeded() {
    if (panicElement) return;

    const panicOverlay = document.createElement('div');
    panicOverlay.style.backgroundColor = 'white';
    panicOverlay.style.border = '3px solid red';
    panicOverlay.style.boxSizing = 'border-box';
    panicOverlay.style.color = 'black';
    panicOverlay.style.display = 'flex';
    panicOverlay.style.height = '100%';
    panicOverlay.style.left = 0;
    panicOverlay.style.padding = '8px';
    panicOverlay.style.position = 'fixed';
    panicOverlay.style.top = 0;
    panicOverlay.style.webkitFlexDirection = 'column';
    panicOverlay.style.width = '100%';

    panicElement = document.createElement('div');
    panicElement.style.webkitFlex = '1 1 auto';
    panicElement.style.overflow = 'auto';

    panicOverlay.appendChild(panicElement);

    if (!document.body) {
        setTimeout(function () {
            document.body.appendChild(panicOverlay);
        }, 150);
    } else {
        document.body.appendChild(panicOverlay);
    }
}

// Panic message display
function showPanic(panicTitle, panicDetails) {
    if (tr.isHeadless) {
        if (panicDetails instanceof Error) throw panicDetails;
        throw new Error('Panic: ' + panicTitle + ':\n' + panicDetails);
    }

    if (panicDetails instanceof Error) {
        panicDetails = panicDetails.stack;
    }

    showPanicElementIfNeeded();

    const panicMessageEl = document.createElement('div');
    panicMessageEl.innerHTML = '<h2 id="message"></h2>' + '<pre id="details"></pre>';
    panicMessageEl.querySelector('#message').textContent = panicTitle;
    panicMessageEl.querySelector('#details').textContent = panicDetails;

    panicElement.appendChild(panicMessageEl);
    rawPanicMessages.push({ title: panicTitle, details: panicDetails });
}

// Check for panic messages
function hasPanic() {
    return rawPanicMessages.length !== 0;
}

// Get all panic messages as text
function getPanicText() {
    return rawPanicMessages.map(function (msg) {
        return msg.title;
    }).join(', ');
}

// Export functionality to a specific namespace
function exportTo(namespace, fn) {
    const obj = exportPath(namespace);
    const exports = fn();
    for (const propertyName in exports) {
        const propertyDescriptor = Object.getOwnPropertyDescriptor(exports, propertyName);
        if (propertyDescriptor) {
            Object.defineProperty(obj, propertyName, propertyDescriptor);
        }
    }
}

// Initialization function to determine the environment
function initialize() {
    if (global.isVinn) {
        tr.isVinn = true;
    } else if (global.process && global.process.versions.node) {
        tr.isNode = true;
    } else {
        tr.isVinn = false;
        tr.isNode = false;
        tr.doc = document;
        tr.isMac = /Mac/.test(navigator.platform);
        tr.isWindows = /Win/.test(navigator.platform);
        tr.isChromeOS = /CrOS/.test(navigator.userAgent);
        tr.isLinux = /Linux/.test(navigator.userAgent);
    }
    tr.isHeadless = tr.isVinn || tr.isNode;
}

// EventTarget class and methods
tr.exportTo('tr.b', function () {
    function EventTarget() { }

    EventTarget.decorate = function (target) {
        for (const k in EventTarget.prototype) {
            if (k === 'decorate') continue;
            const v = EventTarget.prototype[k];
            if (typeof v !== 'function') continue;
            target[k] = v;
        }
    };

    EventTarget.prototype = {
        addEventListener(type, handler) {
            if (!this.listeners_) {
                this.listeners_ = Object.create(null);
            }
            if (!(type in this.listeners_)) {
                this.listeners_[type] = [handler];
            } else {
                const handlers = this.listeners_[type];
                if (handlers.indexOf(handler) < 0) {
                    handlers.push(handler);
                }
            }
        },
        removeEventListener(type, handler) {
            if (!this.listeners_) return;
            if (type in this.listeners_) {
                const handlers = this.listeners_[type];
                const index = handlers.indexOf(handler);
                if (index >= 0) {
                    if (handlers.length === 1) {
                        delete this.listeners_[type];
                    } else {
                        handlers.splice(index, 1);
                    }
                }
            }
        },
        dispatchEvent(event) {
            if (!this.listeners_) return true;
            event.__defineGetter__('target', () => this);
            const realPreventDefault = event.preventDefault;
            event.preventDefault = function () {
                realPreventDefault.call(this);
                this.rawReturnValue = false;
            };
            const type = event.type;
            let prevented = 0;
            if (type in this.listeners_) {
                const handlers = this.listeners_[type].concat();
                for (let i = 0, handler; handler = handlers[i]; i++) {
                    if (handler.handleEvent) {
                        prevented |= handler.handleEvent.call(handler, event) === false;
                    } else {
                        prevented |= handler.call(this, event) === false;
                    }
                }
            }
            return !prevented && event.rawReturnValue;
        },
        async dispatchAsync(event) {
            if (!this.listeners_) return true;
            const listeners = this.listeners_[event.type];
            if (listeners === undefined) return;
            await Promise.all(listeners.slice().map(listener => {
                if (listener.handleEvent) {
                    return listener.handleEvent.call(listener, event);
                }
                return listener.call(this, event);
            }));
        },
        hasEventListener(type) {
            return this.listeners_ !== undefined && this.listeners_[type] !== undefined;
        }
    };

    return { EventTarget };
});

tr.initialize();
