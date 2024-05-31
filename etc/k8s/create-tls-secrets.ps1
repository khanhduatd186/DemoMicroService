mkcert "demomicroservice.dev" "*.demomicroservice.dev" 
kubectl create namespace demomicroservice
kubectl create secret tls -n demomicroservice demomicroservice-tls --cert=./demomicroservice.dev+1.pem  --key=./demomicroservice.dev+1-key.pem