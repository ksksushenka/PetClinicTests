pipeline {
    agent any

    environment {
        PetclinicURL = 'http://localhost:4200/petclinic/'
        PetclinicAPI = 'http://localhost:9966/petclinic/'
        PetClinic = 'Host=localhost;Port=5433;Database=petclinic;username=petclinic;password=petclinic'
        HEADLESS = 'true'
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }

        stage('Install Playwright Browsers') {
            steps {
                bat 'powershell -ExecutionPolicy Bypass -File bin/Debug/net10.0/playwright.ps1 install'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --logger:nunit --results-directory TestResults'
            }
        }

        stage('Allure Report') {
            steps {
                allure([
                    results: [[path: 'allure-results']]
                ])
            }
        }
    }

    post {
        always {
            nunit testResultsPattern: 'TestResults/*.xml'
        }
    }
}