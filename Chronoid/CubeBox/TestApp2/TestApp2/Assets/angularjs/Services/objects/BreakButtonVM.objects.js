//sample in creating object in angularjs
angular.module('otherApp')
.factory('BreakButtonObject', function () {
    var object=function Property(ntitle, nvalue, nbuttonColor, enableHours, enableMinutes, disableHours, disableMinutes, limit, enabled) {
        this.title = ntitle;
        this.value = nvalue;
        this.buttonColor = nbuttonColor;
        this.enableHours=enableHours;
        this.enableMinutes = enableMinutes;
        this.disableHours = disableHours;
        this.disableMinutes = disableMinutes;
        this.limit = limit;
        this.enabled = enabled;
    }
    return object;
});