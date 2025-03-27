debugger;
$(document).ready(function () {
    // Flag to prevent logout request when navigating to another URL
    let shouldLogout = true;

    // Function to send the logout request
    function sendLogoutRequest() {
        $.ajax({
            type: "POST",
            url: "/Home/LogOut/"
        });
    }
    debugger;
    // Trigger logout request when the browser is closed
    $(window).on('beforeunload', function () {
        if (shouldLogout) {
            sendLogoutRequest();
            //shouldLogout = true;
        }
    });

    // Prevent logout request when navigating to another URL
    $(document).on('click', 'a', function () {
        shouldLogout = false;
    });

    $(document).on('click', 'button', function () {
        shouldLogout = false;
    });




    debugger;
    function isBrowserClosed() {
        let browserClosed = false;
        debugger;
        // Add a beforeunload event listener
        window.addEventListener('beforeunload', function (event) {
            // This message is not actually displayed to the user in modern browsers
            //event.returnValue = 'Are you sure you want to leave?';
            browserClosed = true;
            shouldLogout = true;
        });

        // Check if the browser is closed
        function checkBrowserClosed() {
            return browserClosed;
        }

        return checkBrowserClosed;
    }

    // Usage
    const checkClosed = isBrowserClosed();

    // Later, you can check if the browser is closed or not
    if (checkClosed()) {
        shouldLogout = true;
        console.log('Browser is closed');
    } else {
        shouldLogout = false;
        console.log('Browser is still open');
    }



    //// Re-enable logout request when navigating back to the specified URL
    //$(window).on('popstate', function (event) {
    //    if (event.originalEvent.state && event.originalEvent.state.page === 'home') {
    //        shouldLogout = true;
    //    }
    //});


    //window.addEventListener('DOMContentLoaded', function (e) {
    //    console.log="Load";
    //    e.preventDefault();
    //    e.returnValue = '';
    //    shouldLogout = true;

    //});


});