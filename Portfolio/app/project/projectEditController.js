(function () {

    "use strict";
    angular.module("portfolio")
            .controller("projectEditController",
                        ["project", "$state",  projectEditController]);

    function projectEditController(project, $state) {
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

        vm.cancel = function () {
            $state.go('home');
        };

        vm.submit = function () {
            vm.project.$update({ projectId: vm.project.projectId }, vm.project);
            toastr.success("Project updated.");
            $state.go('home');
        };
    }

   

})();