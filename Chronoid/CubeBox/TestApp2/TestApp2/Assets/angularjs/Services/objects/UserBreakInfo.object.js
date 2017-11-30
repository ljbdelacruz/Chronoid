//sample in creating object in angularjs
angular.module('otherApp')
.factory('UserBreakInfoObject', function () {
    var object = function Property(id, timeStarted, timeEnded, breakType) {
        this.id = id;
        this.timeStarted = timeStarted;
        this.timeEnded = timeEnded;
        this.breakType = breakType;
    }
    return object;
});