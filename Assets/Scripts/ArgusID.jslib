mergeInto(LibraryManager.library, {
  InitiateLogin: function () {
    try {
      window.dispatchReactUnityEvent("InitiateLogin");
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
});
