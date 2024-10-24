   * }
     */
    private static final String METHOD_PREFIX = "onBusEvent";
    private static final String INTERPROCESS_METHOD_PREFIX = "onInterprocessBusEvent";

    // Ensures that interprocess events can only be sent from a process holding this permission. */
    private static final String PERMISSION_SELF = "com.android.systemui.permission.SELF";

    // Used for passing event data across process boundaries
    private static final String EXTRA_INTERPROCESS_EVENT_BUNDLE = "interprocess_event_bundle";

    // The default priority of all subscribers
    private static final int DEFAULT_SUBSCRIBER_PRIORITY = 1;

    // Orders the handlers by priority and registration time
    private static final Comparator<EventHandler> EVENT_HANDLER_COMPARATOR = new Comparator<EventHandler>() {
        @Override
        public int compare(EventHandler h1, EventHandler h2) {
            // Rank the handlers by priority descending, followed by registration time descending.
            // aka. the later registered
            if (h1.priority != h2.priority) {
                return h2.priority - h1.priority;
            } else {
                return Long.compare(h2.subscriber.registrationTime, h1.subscriber.registrationTime);
            }
        }
    };

    // Used for initializing the default bus
    private static final Object sLock = new Object();
    private static volatile EventBus sDefaultBus;

    // The handler to post all events
    private Handler mHandler;

    // Keep track of whether we have registered a broadcast receiver already, so that we can
    // unregister ourselves before re-registering again with a new IntentFilter.
    private boolean mHasRegisteredReceiver;

    /**
     * Map from event class -> event handler list.  Keeps track of the actual mapping from event
     * to subscriber method.
     */
    private HashMap<Class<? extends Event>, ArrayList<EventHandler>> mEventTypeMap = new HashMap<>();

    /**
     * Map from subscriber class -> event handler method lists.  Used to determine upon registration
     * of a new subscriber whether we need to read all the subscriber's methods again using
     * reflection or whether we can just add the subscriber to the event type map.
     */
    private HashMap<Class<? extends Object>, ArrayList<EventHandlerMethod>> mSubscriberTypeMap = new HashMap<>();

    /**
     * Map from interprocess event name -> interprocess event class.  Used for mapping the event
     * name after receiving the broadcast, to the event type.  After which a new instance is created
     * and posted in the local process.
     */
    private HashMap<String, Class<? extends InterprocessEvent>> mInterprocessEventNameMap = new HashMap<>();

    /**
     * Set of all currently registered subscribers
     */
    private ArrayList<Subscriber> mSubscribers = new ArrayList<>();

    // For tracing
    private int mCallCount;
    private long mCallDurationMicros;

    /**
     * Private constructor to create an event bus for a given looper.
     */
    private EventBus(Looper looper) {
        mHandler = new Handler(looper);
    }

    /**
     * @return the default event bus for the application's main thread.
     */
    public static EventBus getDefault() {
        if (sDefaultBus == null)
        synchronized (sLock) {
            if (sDefaultBus == null) {
                if (DEBUG_TRACE_ALL) {
                    logWithPid("New EventBus");
                }
                sDefaultBus = new EventBus(Looper.getMainLooper());
            }
        }
        return sDefaultBus;
    }

    /**
     * Registers a subscriber to receive events with th