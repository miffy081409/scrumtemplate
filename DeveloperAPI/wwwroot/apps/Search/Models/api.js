var searchAppModule = window.searchApp;

searchAppModule.service('apiModel', function () {

    var apiArray = new Array();

    var testData = function () {
        for (var ctr = 1; ctr <= 10; ctr++) {
            apiArray[ctr - 1] = { ID: ctr, Title: 'API Name ' + ctr, Description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum' };
        }

        return apiArray;
    };

    this.getData = function ()
    {
        return testData();
    };
});