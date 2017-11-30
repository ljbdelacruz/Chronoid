angular.module('otherApp')
.factory('AlertUtility', [function () {
    return function (breakType, output) {
        var temp = {};
        switch (Number(breakType)) {
            case 1:
                temp = { title: "Morning", message: "Morning" };
                break;
            case 2:
                temp = { title: "Lunch", message: "Lunch" };
                break;
            case 3:
                temp = { title: "Afternoon", message: "Afternoon" };
                break;
            case 4:
                temp = { title: "Side-by-Side", message: "Side-by-Side" };
                break;
            case 5:
                temp = { title: "One-on-One", message: "One-on-One" };
                break;
            case 6:
                temp = { title: "BIO", message: "BIO" };
                break;
            case 7:
                temp = { title: "AFK", message: "AFK" };
                break;
        }
        return temp;
    }


}]);