'use strict';

/**
 * @ngdoc function
 * @name noshwebApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the noshwebApp
 */
angular.module('noshwebApp')
  .controller('MainCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
