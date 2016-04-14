(function () {

    "use strict";

    angular.module("common.services")
        .factory("projectResource", 
                    ["$resource", projectResource]);

    function projectResource($resource) {
        return $resource("/v1/api/portfolio/1/1");
    }
})();