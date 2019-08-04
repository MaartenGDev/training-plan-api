pipeline {
    agent any
    environment {
        DOCKER_IMAGE_NAME = "maartendev/training-plan-api"
        DOCKER_REGISTRY= "340535573758.dkr.ecr.eu-west-1.amazonaws.com"
        DOCKER_IMAGE_URL = "${env.DOCKER_REGISTRY}/${env.DOCKER_IMAGE_NAME}"
    }
    stages {
        stage('Build') {
            steps {
                script {
                    app = docker.build(DOCKER_IMAGE_NAME)
                }
            }
        }
        stage('Push Docker Image') {
            steps {
                script {
                    docker.withRegistry(DOCKER_REGISTRY, 'docker_registry_login') {
                        app.push("${env.GIT_COMMIT}")
                        app.push("latest")
                    }
                }
            }
        }
        stage('Deploy') {
            steps {
                kubernetesDeploy(
                    kubeconfigId: 'kubeconfig',
                    configs: 'train-schedule-kube.yml',
                    enableConfigSubstitution: true
                )
            }
        }
    }
}