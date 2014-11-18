'use strict';

angular.module('noshwebApp')
	.factory('MenusSvc', ['$resource', function($resource){
		return $resource("http://nosh.apphb.com/api/menus", {}, {
    		query: { method: "GET", isArray: true }
  			});
		}]);
