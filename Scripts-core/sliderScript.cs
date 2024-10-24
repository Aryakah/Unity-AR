/*
 * Copyright (C) 2015 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.android.systemui.recents.events.activity;

import com.android.systemui.recents.events.EventBus;

/**
 * Event sent when the exit animation is started.
 *
 * This is sent so parts of UI can synchronize on this event and adjust their appearance. An example
 * of that is hiding the tasks when the launched application window becomes visible.
 */
public class ExitRecentsWindowFirstAnimationFrameEvent extends EventBus.Event {
}
/*
 * Copyright (C) 2015 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.android.systemui.recents.events.activity;

import com.android.systemui.recents.events.EventBus;

/**
 * This is sent when the user taps on the Home button or finishes alt-tabbing to hide the Recents
 * activity.
 */
public class HideRecentsEvent extends EventBus.Event {

    public final boolean triggeredFromAltTab;
    public final boolean triggeredFromHomeKey;

    public HideRecentsEvent(boolean triggeredFromAltTab, boolean triggeredFromHomeKey) {
        this.triggeredFromAltTab = triggeredFromAltTab;
        this.triggeredFromHomeKey = triggeredFromHomeKey;
    }
}
/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.android.systemui.recents.events.activity;

import com.android.systemui.recents.events.EventBus;

/**
 * This is sent when the stack action button should be hidden.
 */
public class HideStackActionButtonEvent extends EventBus.Event {

    // Whether or not to translate the stack action button when hiding it
    public final boolean translate;

    public HideStackActionButtonEvent() {
        this(true);
    }

    public HideStackActionButtonEvent(boolean translate) {
        this.translate = translate;
    }
}
/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.android.systemui.recents.events.activity;

import com.android.systemui.recents.events.EventBus;

/**
 * This event is sent to request that the most recent task is launched.
 */
public class LaunchMostRecentTaskRequestEvent extends EventBus.Event {
    // Simple event
}
