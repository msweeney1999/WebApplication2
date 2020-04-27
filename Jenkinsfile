pipeline {
  agent any
  stages {
    stage('Checkout') {
      steps {
        git 'https://github.com/msweeney1999/WebApplication2.git'
      }
    }
    stage('Restore') {
      steps {
        sh 'dotnet restore'
      }
    }
    stage('Build') {
      steps {
        
        sh 'dotnet build'
      }
    }
    stage('Package') {
        steps {
            sh 'cd WebApplication2'
            sh 'dotnet package'
        }
    }
  
  }
  
 
  environment {
    ASPNETCORE_ENVIRONMENT = 'Production'
  }
}