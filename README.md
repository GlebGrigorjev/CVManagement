# CvManagement 🗎 🗎 🗎

CvManagement is a full-stack web application that empowers users to create, edit, view, and delete their CV information. 
It leverages Angular for the frontend and C#/.NET for the backend, offering a dynamic and interactive platform for managing CVs.

## Live Project:

This project has been deployed using GitHub Pages and Azure hosting service. You can view the live version by [clicking here](https://glebgrigorjev.github.io/CvManagement/).

## How It's Made
**Backend Includes:**

- LatvijasPasts: API controllers for interacting with CV data and startup configurations.
- LatvijasPasts.Core: Core models and entities for managing CV data.
- LatvijasPasts.Data: DBContext model and migration info for database management.
- LatvijasPasts.Services: Service models for implementing business logic.
- LatvijasPasts.UseCases: Mediator pattern implementation for handling CV data use cases, including AutoMapper configuration and FluentValidations for data validation.
- LatvijasPasts.Test: Comprehensive unit tests covering all main parts of the program.

**Frontend Includes:**

*Components:*
- cv-list: List and manage CVs.
- cv-details: View detailed information about a CV.
- create-cv: Create a new CV.
- edit-cv: Edit an existing CV.
- header: Header and navigation components.

*Services:*
- get-cv-list-service: Fetch CV data from the backend API.
- delete-cv-service: Delete CV data using the backend API.
- create-cv-service: Create new CV data using the backend API.
- edit-cv-service: Edit existing CV data using the backend API.
- cv-facade-service: Facade service for coordinating interactions between frontend components and backend services.
It encapsulates complex interactions and provides a simplified interface for the frontend to communicate with the backend.
  
*Models:*
- CvData: Represents the structure of CV data used within the application.
  
*Routing:*
- Contains routing configuration for navigating between different views/components.
  
*styles.scss:*
Main SCSS file for defining global styles for the application.

## Technologies Used

**Backend:**

- ASP.NET Core: Cross-platform, high-performance framework for building web applications.
- Entity Framework Core: Object-relational mapper for .NET simplifying data access.
- AutoMapper: Library for object-to-object mapping.
- MediatR: Mediator pattern implementation for handling queries, commands, and events.
- FluentValidation: Library for building strongly-typed validation rules.

**Frontend:**

- Angular: A TypeScript-based open-source web application framework led by the Angular Team at Google.
- Toastr: A JavaScript library for showing notifications in the browser.

## Future Improvements

- Enhanced User Experience: Consider implementing features such as real-time validation, drag-and-drop functionality for CV sections.
- Authentication and Authorization: Implement user authentication and authorization to restrict access to certain functionalities, such as editing or deleting CVs, based on user roles.
- Responsive Design: Ensure the application is fully responsive across various devices and screen sizes to provide a seamless experience for users accessing the platform from different devices.
- Internationalization and Localization: Add support for multiple languages to make the application accessible to a broader audience. This can involve implementing language-specific translations for UI elements and content.
- Performance Optimization: Optimize the application's performance by reducing load times, minimizing network requests, and optimizing database queries to provide a faster and more efficient user experience.

## Lessons Learned

- Angular and ASP.NET Core Integration: Through this project, I gained valuable experience in integrating Angular frontend with ASP.NET Core backend, understanding how to communicate between the two using RESTful APIs.
- Effective Data Management: I learned best practices for managing data in Angular applications, including data fetching, manipulation, and displaying using Angular services, components, and templates.
- Error Handling and Debugging: I improved my skills in error handling and debugging in both frontend and backend environments, learning to effectively identify and resolve issues to ensure smooth application functionality.
- Testing and Quality Assurance: Through writing comprehensive unit tests for the backend using tools like MsTest and Moq, I gained a better understanding of the importance of testing for ensuring code quality and reliability.
- Project Structure and Organization: I learned how to effectively structure and organize a full-stack web application project, including separating concerns, modularizing components and services, and maintaining a clean and scalable codebase.
