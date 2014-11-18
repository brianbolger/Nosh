'use strict';

/**
 * @ngdoc function
 * @name noshwebApp.controller:OrdersCtrl
 * @description
 * # OrdersCtrl
 * Controller of the noshwebApp
 */
angular.module('noshwebApp')
  .controller('OrdersCtrl', function ($scope, OrdersSvc) {

    $scope.orders = [
    	'Mon Sambo',
    	'Tues Soup',
    ];

    OrdersSvc.query(function(data){
      console.log(data[0].contents);
    });
  });
