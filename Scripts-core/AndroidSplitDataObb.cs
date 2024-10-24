  ((TextView) mLayout.findViewById(R.id.screen_pinning_description))
                    .setText(descriptionStringResId);
            final int backBgVisibility = touchExplorationEnabled ? View.INVISIBLE : View.VISIBLE;
            mLayout.findViewById(R.id.screen_pinning_back_bg).setVisibility(backBgVisibility);
            mLayout.findViewById(R.id.screen_pinning_back_bg_light).setVisibility(backBgVisibility);

            addView(mLayout, getRequestLayoutParams(rotation));
        }

        private void swapChildrenIfRtlAndVertical(View group) {
            if (mContext.getResources().getConfiguration().getLayoutDirection()
                    != View.LAYOUT_DIRECTION_RTL) {
                return;
            }
            LinearLayout linearLayout = (LinearLayout) group;
            if (linearLayout.getOrientation() == LinearLayout.VERTICAL) {
                int childCount = linearLayout.getChildCount();
                ArrayList<View> childList = new ArrayList<>(childCount);
                for (int i = 0; i < childCount; i++) {
                    childList.add(linearLayout.getChildAt(i));
                }
                linearLayout.removeAllViews();
                for (int i = childCount - 1; i >= 0; i--) {
                    linearLayout.addView(childList.get(i));
                }
            }
        }

        @Override
        public void onDetachedFromWindow() {
            mContext.unregisterReceiver(mReceiver);
        }

        protected void onConfigurationChanged() {
            removeAllViews();
            inflateView(RotationUtils.getRotation(mContext));
        }

        private final Runnable mUpdateLayoutRunnable = new Runnable() {
            @Override
            public void run() {
                if (mLayout != null && mLayout.getParent() != null) {
                    mLayout.setLayoutParams(getRequestLayoutParams(RotationUtils.getRotation(mContext)));
                }
            }
        };

        private final BroadcastReceiver mReceiver = new BroadcastReceiver() {
            @Override
            public void onReceive(Context context, Intent intent) {
                if (intent.getAction().equals(Intent.ACTION_CONFIGURATION_CHANGED)) {
                    post(mUpdateLayoutRunnable);
                } else if (intent.getAction().equals(Intent.ACTION_USER_SWITCHED)
                        || intent.getAction().equals(Intent.ACTION_SCREEN_OFF)) {
                    clearPrompt();
                }
            }
        };
    }

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              