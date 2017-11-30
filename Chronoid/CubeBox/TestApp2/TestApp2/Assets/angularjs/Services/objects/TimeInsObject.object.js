//sample in creating object in angularjs
angular.module('otherApp')
.factory('TimeInsObject', function () {
    var object = function Property(name, profileImage, schedule, timeInImage, timeInTime, timeOutImage, timeOutTime) {
        this.name = name;
        this.profileImage = profileImage;
        this.schedule = schedule;
        this.timeInImage = timeInImage;
        this.timeInTime = timeInTime;
        this.timeOutImage = timeOutImage;
        this.timeOutTime = timeOutTime;
    }
    return object;
});