window.addEventListener("load", function () {
    // Create Dark Mode Toggle Button
    const darkModeButton = document.createElement('button');
    darkModeButton.innerHTML = '🌙 Dark Mode';
    darkModeButton.style.position = 'fixed';
    darkModeButton.style.top = '20px';
    darkModeButton.style.right = '20px';
    darkModeButton.style.padding = '12px 20px';
    darkModeButton.style.fontSize = '16px';
    darkModeButton.style.fontWeight = 'bold';
    darkModeButton.style.borderRadius = '30px';
    darkModeButton.style.backgroundColor = '#4CAF50';  // Green button color
    darkModeButton.style.color = '#ffffff';  // White text for button
    darkModeButton.style.border = 'none';
    darkModeButton.style.cursor = 'pointer';
    darkModeButton.style.zIndex = '1000';
    darkModeButton.style.transition = 'background-color 0.3s, transform 0.3s';

    // Hover effect on the button
    darkModeButton.addEventListener('mouseenter', function () {
        darkModeButton.style.backgroundColor = '#45a049';
        darkModeButton.style.transform = 'scale(1.1)';
    });
    darkModeButton.addEventListener('mouseleave', function () {
        darkModeButton.style.backgroundColor = '#4CAF50';
        darkModeButton.style.transform = 'scale(1)';
    });

    // Append button to the body
    document.body.appendChild(darkModeButton);

    // Check if dark mode is enabled in localStorage
    const isDarkMode = localStorage.getItem('darkMode') === 'true';

    // Function to apply dark mode styles
    function applyDarkMode() {
        // Apply dark background and white text color for the entire page
        document.body.style.transition = 'background-color 0.5s, color 0.5s';  // Smooth transition
        document.body.style.backgroundColor = '#A9A9A9';  // Dark muted blue-gray background
        document.body.style.color = '#008000';  // White text for better contrast

        // Apply white text and dark background for all Swagger UI elements
        const elements = document.querySelectorAll('.swagger-ui, .swagger-ui .topbar, .swagger-ui .info, .swagger-ui .btn, .swagger-ui .btn:hover, .swagger-ui .description, .swagger-ui .response-col-description, .swagger-ui .model-title, .swagger-ui .section .title, .swagger-ui .filter-input, .swagger-ui .operation-tag, .swagger-ui .model-detail, .swagger-ui .operation-description');
        elements.forEach(element => {
            element.style.backgroundColor = '';  // Muted gray background for UI elements
            element.style.color = '#008000';  // White text for UI elements
            element.style.borderColor = '#008000';  // Muted gray border for UI elements
        });

        // Apply white text for controller names, endpoint routes, and descriptions
        const controllerNames = document.querySelectorAll('.swagger-ui .opblock-tag .opblock-tag-no-desc span, .swagger-ui .opblock-tag a');
        controllerNames.forEach(name => {
            name.style.color = '#008000';  // Ensure controller names are white
        });

        // Apply white text for API endpoint routes (operation summary path)
        const apiEndpointRoutes = document.querySelectorAll('.swagger-ui .opblock-summary-path');
        apiEndpointRoutes.forEach(route => {
            route.style.color ='#000000'  // Set the API route paths to white
        });

        // Apply white text for response and request descriptions
        const descriptions = document.querySelectorAll('.swagger-ui .parameter__description, .swagger-ui .response-col-description, .swagger-ui .operation-description');
        descriptions.forEach(description => {
            description.style.color = '';  // Ensure all descriptions are white
        });

        // Update button text to indicate dark mode is active
        darkModeButton.innerHTML = '🌞 Light Mode';
    }

    // Function to apply light mode styles
    function applyLightMode() {

        document.body.style.transition = 'background-color 0.5s, color 0.5s';  // Smooth transition
        document.body.style.backgroundColor = '';  
        document.body.style.color = '';  

        const elements = document.querySelectorAll('.swagger-ui, .swagger-ui .topbar, .swagger-ui .info, .swagger-ui .btn, .swagger-ui .btn:hover, .swagger-ui .description, .swagger-ui .response-col-description, .swagger-ui .model-title, .swagger-ui .section .title, .swagger-ui .filter-input, .swagger-ui .operation-tag, .swagger-ui .model-detail, .swagger-ui .operation-description');
        elements.forEach(element => {
            element.style.backgroundColor = '';  
            element.style.color = '';  
            element.style.borderColor = ''; 
        });

        const controllerNames = document.querySelectorAll('.swagger-ui .opblock-tag .opblock-tag-no-desc span, .swagger-ui .opblock-tag a');
        controllerNames.forEach(name => {
            name.style.color = ''; 
        });

        const apiEndpointRoutes = document.querySelectorAll('.swagger-ui .opblock-summary-path');
        apiEndpointRoutes.forEach(route => {
            route.style.color = '';  
        });

        const descriptions = document.querySelectorAll('.swagger-ui .parameter__description, .swagger-ui .response-col-description, .swagger-ui .operation-description');
        descriptions.forEach(description => {
            description.style.color = ''; 
        });

        // Update button text to indicate light mode is active
        darkModeButton.innerHTML = '🌙 Dark Mode';
    }

    // Apply the correct mode based on localStorage
    if (isDarkMode) {
        applyDarkMode();
    } else {
        applyLightMode();
    }

    // Toggle between dark and light mode when the button is clicked
    darkModeButton.addEventListener('click', function () {
        const isCurrentlyDarkMode = localStorage.getItem('darkMode') === 'true';
        if (isCurrentlyDarkMode) {
            // Switch to light mode
            applyLightMode();
            localStorage.setItem('darkMode', 'false');
        } else {
            // Switch to dark mode
            applyDarkMode();
            localStorage.setItem('darkMode', 'true');
        }
    });
});




