'use strict';

angular.module('noshwebApp')
	.factory('OrdersSvc', ['$resource', function($resource){
		return $resource("http://nosh.apphb.com/api/users/joey/orders", {}, {
    		query: { method: "GET", isArray: true }
  			});
		}]);
