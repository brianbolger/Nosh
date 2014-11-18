'use strict';

/**
 * @ngdoc function
 * @name noshwebApp.controller:MenusCtrl
 * @description
 * # MenusCtrl
 * Controller of the noshwebApp
 */
angular.module('noshwebApp')
  .controller('MenusCtrl', MenusController)
  .controller('MenuDetailsCtrl', MenuDetailsController);


function MenusController($scope, MenusSvc){
  $scope.menus = [
    'Mortons',
    'KC Peaches',
    'Other'
  ];

  MenusSvc.query(function(data){
    $scope.menus.push(data[0].name);
  });
}

function MenuDetailsController($scope, $routeParams){
  $scope.currentMenu = $routeParams.menuId;
}
