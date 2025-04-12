## What's New in React 19 by Roland Guijt

- OVERVIEW:
    - This course will teach you how to work with new hooks such as use, useActionState, and useOptimistic (form) actions, and the new possibility to create server components and functions.

- SERVER COMPONENTS AND ACTIONS:
    - Benefits of server-side code:
        - Server-rendered applications:
            - Caching.
            - Secrets: API keys. OAuth tokens.
            - Libraries: Browser receives minimal required.
            - Feels fater: Especially with first access.
                - Otherwise. SPA downloaded. Then data. SPA downloads all at application start.
        - SPA upsides:
            - Smooth UX. No server routes needed. 
                - And, really, no server after initial download. API needed to manage data.
            - Tend to scale better.
            - Offline possibilities.
        - Server-side features offer the best of both worlds. Go figure.
            - Client-side components. Browser-side components. And server-side actions.
    - Server components:
        - components that are rendered on the browser:
            - State. Fetch. And then place in state. And then render the state to JSX.
                - useState and useEffect are needed is for re-rendering cycle.
                - Whenever any state that is used by this component, or a parent component, changes.
                    - This function is re-executed. And then the variable is re-initialized.
                ```javascript
                    useEffect(() => {
                        const fetchHouses = async () => {
                        const response = await
                            fetch("https://localhost:7057/house");
                        const houses = await response.json();      
                        setHouses(houses);
                        };
                        fetchHouses();
                    }, []);
                ```
            - Server-side features. Next.js.
                ```javascript
                    const houses = await fetch("http://localhost:5285/house")
                        .then(r => r.json());
                ```
                - With client-side child:
                    ```javascript
                        {houses.map((h) => (
                        <HouseRow key={h.id} house={h} />
                        ))}
                    ```
            - With the router, pages are used which are server components.
                - e.g.: The file determines the route. Browser requests the route and then the page is served.
            - All on server. No need for useState and useEffect. Code will just run when JURL is requested.
                - Note: Can call db within server-side route. Links cause a round trip to the server.
    - Mixing server and client components:
        - DOWNSIDE: Server components don't support interactivity. e.g.: event handlers.
            - "use client" e.g.: AddHouseButton component.
                ```javascript
                    <ErrorBoundary fallback="Error adding house!">
                        <AddHouseButton />
                    </ErrorBoundary>
                ```
            - Client components can be children of server components.
                - All components rendered by client omponents are also client components.
                - Server component can be passaed as a child to client component.
    - Server actions:
        - Modules (and individual functions) can be marked as "use server" and imported.
        - Actions are executed in a transition context.
        - How, then, does the server component update the client component.
            - Tell next.js that the route path is out of date.
                - `revalidatePath("/");`
            - The component code will automatically be re-run and the UI will be updated.
            - React Server Component Payload. Re-render on the server and send the complete HTML.
                - Update the UI without re-rendering the entire page.
        - Server action uses:
            - Direct data source access.
            - Large functions or libraries used.
            - APIs that browsers cannot access. e.g.: file system.
    - Considering server-side features:
        - Need Next.js. Very opinated. Built-in router. Special components to support.
        - Two parts to deploy. Server. Browser-side. Hosting options.
        - NOT for beginners.

- FORM ACTIONS AND NEW HOOKS:

- IMPROVEMENTS AND ENHANCEMENTS:
