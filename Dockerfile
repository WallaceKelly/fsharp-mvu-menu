FROM mcr.microsoft.com/dotnet/sdk:5.0
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
WORKDIR /workspaces/fsharp-mvu-menu

# install npm
COPY package.json package-lock.json ./
RUN apt-get update -yq && \
    apt-get install npm -yq && \
    npm install -yq 

# initialize dotnet
COPY .config/ ./src/App.fsproj ./
RUN dotnet tool restore && \
    dotnet restore ./src/App.fsproj

# copy over all files (except for .dockerignore-d files)
COPY ./ ./

RUN npm run build
ENTRYPOINT npm start
