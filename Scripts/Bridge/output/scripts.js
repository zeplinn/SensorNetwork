(function (globals) {
    "use strict";

    Bridge.define('Scripts.App', {
        statics: {
            config: {
                init: function () {
                    Bridge.ready(this.main);
                }
            },
            main: function () {
                // Simple alert() to confirm it's working
                Bridge.global.alert("Success");
            }
        }
    });
    
    Bridge.init();
})(this);
