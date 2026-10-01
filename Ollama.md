# Ollama

```
ollama launch codex
ollama launch opencode
ollama launch copilot
ollama
```

With 8 Go of VRAM
gemma4 2B For Reliability and Speed
gemma4 7b For Optimal Performance
Use a Q4_K_M quantized version in the GGUF format.

```
ollama --help
```

```
ollama run gemma4:e2b-it-q4_K_M
ollama run gemma:7b-instruct-q4_K_M
```

https://ollama.com/library/gemma4
```
ollama run gemma4:31b-cloud
ollama run gemma4:e2b
ollama run gemma4:e4b
```

```
ollama pull nimble
```

Sur Mac, on peut lancer les modèles suivants (cela les installera) :
```
ollama run gemma4:e2b-mlx
ollama run gemma4:e4b-mlx
ollama run gemma4:12b-mlx
```

On peut supprimer des modèles avec la commande suivante :
```
ollama rm llama3
ollama rm gpt-oss:20b
ollama rm gemma3
ollama rm gemma3:4b
```
