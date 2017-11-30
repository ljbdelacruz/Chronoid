'use strict';

/*Note:*/
/*Requirements in using this directive*/
/*it includes Interactable1 Directives*/

angular.module('directives.table1', [])
    .directive('table1', ['$http',
        '$location', '$timeout',
        function ($http, $location, $timeout) {

            function preFn(scope, element, attr) {
            }
            / Do the directive's logic here /
            /*this table is for delete, edit functionality*/
            /*json pattern for option*/

            function postFn(scope, element, attr) {
                //scope.options = [{ icon: 'mdi-communication-email', option: '1' },
                // { icon: 'mdi-editor-insert-invitation', option: '2' }];
                scope.ModifyRecord = function (item, action) {
                    scope.outputSelectedRow = item;
                    scope.tableTaskRowSelected = item;
                    scope.actionSelected = action;
                    scope.actionTaskSelected = action;
                    //time delay before executing event
                    $timeout(function () {
                        scope.event(item, action);
                    }, 100);
                };
            }
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    header: '=',
                    items: '=',
                    rowOptions: '=',
                    outputSelectedRow: '=',
                    tableTaskRowSelected: '=',
                    actionSelected: '=',
                    actionTaskSelected: '=',
                    event: '&',
                    icon: '=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/DataTables/Table1/Table1.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);