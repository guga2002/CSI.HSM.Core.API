pipeline {
    agent any

    environment {
        DOTNET_ROOT = "/usr/share/dotnet"
        PATH = "/usr/share/dotnet:${env.PATH}"
    }

    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore CSI.HSM.Core.API/Core.API.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build  CSI.HSM.Core.API/Core.API.csproj --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish  CSI.HSM.Core.API/Core.API.csproj --configuration Release -o ~/apps/CsiApi'
            }
        }

        stage('Restart Service') {
            steps {
                sh 'sudo systemctl restart csi-core.service'
            }
        }
    }
}
