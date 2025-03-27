pipeline {
    agent any

    environment {
        DOTNET_ROOT = "/usr/share/dotnet"
        PATH = "/usr/share/dotnet:${env.PATH}"
    }

    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore Core.API.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build Core.API.csproj --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish Core.API.csproj --configuration Release -o ~/apps/CsiApi'
            }
        }

        stage('Restart Service') {
            steps {
                sh 'sudo systemctl restart csi-core.service'
            }
        }
    }
}
