pipeline {
    agent any

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
                bat 'pwsh bin/Debug/net10.0/playwright.ps1 install'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --logger "trx;LogFileName=testResults.trx"'
            }
        }
    }

    post {
        always {
            junit '**/*.trx'
        }
    }
}