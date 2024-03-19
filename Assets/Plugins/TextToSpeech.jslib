mergeInto(LibraryManager.library, {
    gameObject: "",
    liveTranscribeCallback: "",
    finalResultCallback: "",
    recognition: "",

    CheckBrowserSupported: function(){
        if ('webkitSpeechRecognition' in window) return true;
        return false;
    },

    SetupSpeechRecognition: function(gameObjectName, liveTranscribeCallbackName, finalResultCallbackName) {
            recognition = new webkitSpeechRecognition();
            recognition.continuous = false;
            recognition.interimResults = true;
            gameObject = UTF8ToString(gameObjectName);
            liveTranscribeCallback = UTF8ToString(liveTranscribeCallbackName);
            finalResultCallback = UTF8ToString(finalResultCallbackName);

            recognition.onresult = function(event) {
                if(!event.results[0].isFinal){
                    SendMessage(gameObject, liveTranscribeCallback, event.results[0][0].transcript);
                } else{
                    SendMessage(gameObject, finalResultCallback, event.results[0][0].transcript);
                }
            };
    },

    StartSpeechRecognition: function() {
            recognition.start();
    }

});
