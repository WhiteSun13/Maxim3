mergeInto(LibraryManager.library, {

  ShowFullscreen: function () {
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function(wasShown) {
            console.log('Реклама Fullscreen открылась.');
            myGameInstance.SendMessage("YaAd", "StopBeforeAd");
          },
          onClose: function(wasShown) {
            console.log("Реклама Fullscreen закрылась.");
            myGameInstance.SendMessage("YaAd", "ResumeAfterAd");
          },
          onError: function(error) {
            console.log("Ошибка по рекламе Fullscreen.");
          }
      }
      })
  },
  ShowDevice: function () {
    if (ysdk.deviceInfo.isMobile() || ysdk.deviceInfo.isTablet()){
      myGameInstance.SendMessage('YaAd', 'GettingDevice', 'mobile');
    }
  },
  ShowRewarded: function () {
      ysdk.adv.showRewardedVideo({
      callbacks: {
          onOpen: () => {
            console.log('Реклама Rewarded открылась.');
          },
          onRewarded: () => {
            console.log('Реклама Rewarded просмотрена, и производим награду игроку за просмотр.');
          },
          onClose: () => {
            console.log('Реклама Rewarded закрылась.');
          }, 
          onError: (e) => {
            console.log('Ошибка по рекламе Rewarded:', e);
          }
      }
  })
  },

});