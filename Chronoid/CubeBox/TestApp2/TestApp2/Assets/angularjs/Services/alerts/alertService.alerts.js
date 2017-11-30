
angular.module('otherApp')
.factory('AlertService', ['$mdDialog', function ($mdDialog) {
    /*PATH TO POST THE DATA AND PARAM IS FOR THE PARAMETER OF THAT API*/
    var data = function () {
        this.OpenFromLeft = function () {
            return $mdDialog.show(
              $mdDialog.alert()
                .clickOutsideToClose(true)
                .title('Opening from the left')
                .textContent('Closing to the right!')
                .ariaLabel('Left to right demo')
                .ok('Nice!')
                // You can specify either sting with query selector
                .openFrom('#left')
                // or an element
                .closeTo(angular.element(document.querySelector('#right')))
            );
        }



    }
    return data;
}]);