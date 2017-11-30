//sample in creating object in angularjs
angular.module('otherApp')
.factory('TimeObject', function () {
    var object=function Property(nhour, nmins, nsecs, Day, day, year, Month, month) {
        this.hour = nhour;
        this.minute = nmins;
        this.second = nsecs;
        this.Day = Day;
        this.day = day;
        this.year = year;
        this.Month = Month;
        this.month = month;
    }
    return object;
});