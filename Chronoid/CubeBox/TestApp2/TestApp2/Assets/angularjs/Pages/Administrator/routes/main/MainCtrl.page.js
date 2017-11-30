angular.module('modules.Main')
.controller('MainCtrl',
            ['$scope', '$http', '$route', '$location',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'AlertUtility',
               'CustomTimout',
               /*global*/
               'GlobalizationUser',

             function ($scope, $http,$route,$location,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       AlertUtility,
                       CustomTimout,
                       GlobalizationUser) {
                 // UI Stuff
                 $scope.navigationController = {};
                 $scope.navigationController.options = [];
                 $scope.navigationController.Assign = function () {
                     $scope.navigationController.options = [
                         {
                             bgColor: '#0aa699',
                             icon: '',
                             title: 'INVENTORY',
                             options: [
                               { title: 'Items', data: '209', link: '' }
                             ],
                             description: 'Shows Inventory Process'
                         },
                         {
                             bgColor: '#6f5d81',
                             icon: '',
                             title: 'Sales',
                             options: [
                               { title: 'Marketing', data: '1', link: '' },
                               { title: 'Operation Manager', data: '1', link: '' }
                             ],
                             description: 'Shows Sales and Reservation Process...'
                         },
                         {
                             bgColor: '#0090d9',
                             icon:'',
                             title: 'People',
                             options: [
                               { title: 'Employees', data: GlobalizationUser.count, link: '/Employee' },
                               { title: 'Users', data: '', link: '/Settings' },
                             ],
                             description: 'Shows Transaction for HR...'
                         },
                         {
                             bgColor: '#0090d9',
                             icon: '',
                             title: 'Settings',
                             options: [
                               { title: 'Breaks', data: GlobalizationUser.count, link: '/Settings/Breaks' }
                             ],
                             description: 'Shows Transaction for HR...'
                         }];
                 }
                 $scope.navigationController.Assign();


                 $scope.navigationController.navigatePath = function (url) {
                     $location.path(url);
                 }
                 //end here
                 $scope.watcherController = {};
                 //this watches the values change in count
                 $scope.$watch(GlobalizationUser.count, $scope.navigationController.Assign());
                 //constructors
                 $scope.constructor = function () {
                     $scope.navigationController.Assign();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);