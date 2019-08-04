pipeline {
  agent {
    kubernetes {
      label 'mypod'
      yaml """
apiVersion: v1
kind: Pod
spec:
  containers:
  - name: docker
    image: docker:1.11
    command: ['cat']
    tty: true
    volumeMounts:
    - name: dockersock
      mountPath: /var/run/docker.sock
  volumes:
  - name: dockersock
    hostPath:
      path: /var/run/docker.sock
"""
    }
  }
  environment {
    DOCKER_IMAGE_NAME = "maartendev/training-plan-api"
    DOCKER_REGISTRY= "340535573758.dkr.ecr.eu-west-1.amazonaws.com"
    DOCKER_IMAGE_URL = "${env.DOCKER_REGISTRY}/${env.DOCKER_IMAGE_NAME}"
  }
  stages {
        stage('Build') {
            steps {
                container('docker') {
                    script {
                        app = docker.build(DOCKER_IMAGE_NAME)
                    }
                }
            }
        }
        stage('Push Docker Image') {
            steps {
                container('docker') {
                    script {
                        docker.withRegistry("${DOCKER_REGISTRY}", 'ecr:eu-west-1:docker_registry_login') {
                            app.push("${env.GIT_COMMIT}")
                            app.push("latest")
                        }
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