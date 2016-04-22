(function () {

    "use strict";
    angular.module("portfolio")
            .controller("projectEditController",
                        ["project", projectEditController]);

    function projectEditController(project) {
        var vm = this;
        vm.project = project;
        console.log(project);
        

        vm.openStartDate = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.startDate.opened = !vm.startDate.opened;
        };
        vm.openEndDate = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.endDate.opened = !vm.endDate.opened;
        };

        vm.startDate = {
            opened: false
        };
        vm.endDate = {
            opened: false
        };
    }

   

})();