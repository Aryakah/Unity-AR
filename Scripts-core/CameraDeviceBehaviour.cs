class iaImporter extends tr.importer.Importer {
    constructor(model, eventData) {
        super(model, eventData);
        this.importPriority = IMPORT_PRIORITY;
        this.model_ = model;
        this.events_ = eventData.events;
        this.parsers_ = [];
        this.threadInfo_ = new Map();
        this.processNames_ = new Map();
    }

    // Static method to check if the event data can be imported
    static canImport(eventData) {
        if (eventData instanceof tr.b.TraceStream) {
            if (eventData.isBinary) return false;
            eventData = eventData.header;
        }
        if (eventData instanceof Object && eventData.type === 'fuchsia') {
            return true;
        }
        return false;
    }

    // Getter for importer name
    get importerName() {
        return 'FuchsiaImporter';
    }

    // Getter for model
    get model() {
        return this.model_;
    }

    // Stub for importing clock sync markers (implementation needed)
    importClockSyncMarkers() {}

    // Stub for finalizing the import process (implementation needed)
    finalizeImport() {}

    // Method to process context switch events
    processContextSwitchEvent_(event) {
        let tid = event.in.tid;
        let threadName = tid.toString();
        let procName = '';

        if (this.threadInfo_.has(tid)) {
            const threadInfo = this.threadInfo_.get(tid);
            threadName = threadInfo.name;
            const pid = threadInfo.pid;

            if (this.processNames_.has(pid)) {
                procName = this.processNames_.get(pid) + ':';
            }
        }

        const name = procName + threadName;
        if (tid > IDLE_THREAD_THRESHOLD) {
            tid = undefined;
        }

        const cpu = this.model_.kernel.getOrCreateCpu(event.cpu);
        cpu.switchActiveTh;
    }
}
