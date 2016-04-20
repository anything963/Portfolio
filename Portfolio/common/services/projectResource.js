(function () {

    "use strict";

    angular.module("common.services")
        .factory("projectResource", 
                    ["$resource", projectResource]);

    function projectResource($resource) {
        return $resource("/v1/api/userportfolio/1/project");
    }
})();