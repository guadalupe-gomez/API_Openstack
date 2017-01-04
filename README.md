# API_Openstack

Ejemplo de Api de Openstack con .Net Core


Ejemplo de Dockerfile para correr el ejemplo dentro de un contenedor:

    # We use the microsoft/dotnet image as a starting point.
    FROM microsoft/dotnet:latest
   
    # Install git
    RUN apt-get install git -y

    # Create a folder to clone our source code
    RUN mkdir repositories

    # Set our working folder
    WORKDIR repositories

    #Set environment variables     
    ENV  API_OPENSTACK_IDENTITY "http://10.10.10.10/identity"
    ENV API_OPENSTACK_COMPUTE "http://10.10.10.10:8774/v2.1"
    ENV API_OPENSTACK_USER "demo"
    ENV API_OPENSTACK_PASSWORD "admin"
    ENV API_OPENSTACK_PROJECT_ID "e70b21ba6d19403d95a6d86d96e4d7e2"

    # Clone the source code
    RUN git clone https://github.com/guadalupe-gomez/API_Openstack.git
    
     # Set our working folder
    WORKDIR API_Openstack/src/API_Openstack

    # Expose port 8282 for the application.
    EXPOSE 8282

    # Restore nuget packages
    RUN dotnet restore

    # Start the application using dotnet!!!
    ENTRYPOINT dotnet run

