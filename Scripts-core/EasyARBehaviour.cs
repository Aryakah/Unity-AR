function getTotalCpuDuration(ts) {
    let cpuMs = 0;
    ts.forEach(function(event) {
        if (event.cpuSelfTime) {
            cpuMs += event.cpuSelfTime;
        }
    });
    return cpuMs;
}

function getIRCoverageFromModel(model) {
    const associatedEvents = getAssociatedEvents(model.userModel.expectations);
    if (!associatedEvents.length) return undefined;

    const unassociatedEvents = getUnassociatedEvents(model, associatedEvents);
    const associatedCpuMs = getTotalCpuDuration(associatedEvents);
    const unassociatedCpuMs = getTotalCpuDuration(unassociatedEvents);

    const totalEventCount = associatedEvents.length + unassociatedEvents.length;
    const totalCpuMs = associatedCpuMs + unassociatedCpuMs;

    let coveredEventsCpuTimeRatio = undefined;
    if (totalCpuMs !== 0) {
        coveredEventsCpuTimeRatio = associatedCpuMs / totalCpuMs;
    }

    return {
        associatedEventsCount: associatedEvents.length,
        unassociatedEventsCount: unassociatedEvents.length,
        associatedEventsCpuTimeMs: associatedCpuMs,
        unassociatedEventsCpuTimeMs: unassociatedCpuMs,
        coveredEventsCountRatio: associatedEvents.length / totalEventCount,
        coveredEventsCpuTimeRatio
    };
}

return {
    getIRCoverageFromModel,
    getAssociatedEvents,
    getUnassociatedEvents
};

// Exporting IdleExpectation class
'use strict';
tr.exportTo('tr.model.um', function() {
    function IdleExpectation(parentModel, start, duration) {
        const initiatorTitle = '';
        tr.model.um.UserExpectation.call(this, parentModel, initiatorTitle, start, duration);
    }

    IdleExpectation.prototype = {
        __proto__: tr.model.um.UserExpectation.prototype,
        constructor: IdleExpectation
    };

    tr.model.um.UserExpectation.subTypes.register(IdleExpectation, {
        stageTitle: 'Idle',
        colorId: tr.b.ColorScheme.getColorIdForReservedName('rail_idle')
    });

    return {
        IdleExpectation
    };
});

// Exporting additional functionality from the importer
'use strict';
tr.exportTo('tr.importer', function() {
    const /* Additional functionality can be added here */ 
});
