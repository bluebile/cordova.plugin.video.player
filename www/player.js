var exec = require('cordova/exec');

module.exports = {

	show : function(url) {
		cordova.exec(null, null, 'VideoPlayer', 'show', [ url ]);
    }

};