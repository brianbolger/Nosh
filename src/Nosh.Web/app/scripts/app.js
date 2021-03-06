'use strict';

/**
 * @ngdoc overview
 * @name noshwebApp
 * @description
 * # noshwebApp
 *
 * Main module of the application.
 */
angular
  .module('noshwebApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
      })
      .when('/menus/:menuId', {
        templateUrl: 'views/menus.html',
        controller: 'MenuDetailsCtrl'
      })
      .when('/orders', {
        templateUrl: 'views/orders.html',
        controller: 'OrdersCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
