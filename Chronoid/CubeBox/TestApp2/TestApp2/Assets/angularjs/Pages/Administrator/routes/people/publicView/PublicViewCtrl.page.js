angular.module('modules.PublicView')
.controller('PublicViewCtrl',
            ['$scope', '$http','$route',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'AlertUtility',
               'CustomTimout',
             function ($scope, $http,$route,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       AlertUtility,
                       CustomTimout) {
                


                 //constructors
                 $scope.constructor = function () {

                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/PublicView")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);