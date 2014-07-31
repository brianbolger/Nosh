'use strict';

/**
 * @ngdoc function
 * @name noshwebApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the noshwebApp
 */
angular.module('noshwebApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
