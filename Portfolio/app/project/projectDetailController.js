(function () {

    "use strict";

    angular.module("portfolio")
            .controller("projectDetailController",
                        ["project", projectDetailController]);

    function projectDetailController(project) {
        var vm = this;
        vm.project = project;
        console.log(project);
    }
})();