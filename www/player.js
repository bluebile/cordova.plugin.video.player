var exec = require('cordova/exec');

module.exports = {

	show : function(url) {
		cordova.exec(cancelCallback, null, 'VideoPlayer', 'show', [ url ]);
    }

};