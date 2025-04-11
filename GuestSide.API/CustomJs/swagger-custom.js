(function () {
    document.addEventListener("DOMContentLoaded", function () {
        const interval = setInterval(function () {
            const topbar = document.querySelector('.topbar-wrapper');
            const mainWrapper = document.querySelector('.swagger-ui');

            if (topbar && mainWrapper) {
                clearInterval(interval);

                // ✅ Topbar styling
                topbar.style.backgroundColor = '#0f172a'; // dark blue
                topbar.style.padding = '10px';

                const span = topbar.querySelector('span');
                if (span) {
                    span.innerText = '🚀 LogiXplore API Platform';
                    span.style.color = '#facc15'; // yellow
                    span.style.fontSize = '1.5rem';
                    span.style.fontWeight = 'bold';
                    span.style.letterSpacing = '1px';
                }

                // ❌ Remove Swagger logo if desired
                const logo = topbar.querySelector('img');
                if (logo) {
                    logo.remove();
                }

                // ✅ Change overall font and background
                mainWrapper.style.fontFamily = "'Segoe UI', sans-serif";
                mainWrapper.style.backgroundColor = '#f1f5f9'; // light gray
                mainWrapper.style.padding = '20px';

                // ✅ Highlight method blocks
                document.querySelectorAll('.opblock-summary').forEach(block => {
                    block.style.borderRadius = '8px';
                    block.style.boxShadow = '0 2px 6px rgba(0,0,0,0.1)';
                    block.style.marginBottom = '8px';
                });

                // ✅ Add custom footer
                const footer = document.createElement('div');
                footer.innerHTML = `<div style="
                    background-color: #0f172a;
                    color: #f1f5f9;
                    text-align: center;
                    padding: 15px;
                    font-size: 0.95rem;
                    margin-top: 40px;
                    border-radius: 8px;
                ">
                    © 2025 LogiXplore • Powered by Swagger & .NET
                </div>`;

                mainWrapper.appendChild(footer);
            }
        }, 100);
    });
})();
