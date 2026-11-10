const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5075'

async function request(path, options = {}) {
  const response = await fetch(`${API_URL}${path}`, {
    headers: {
      'Content-Type': 'application/json',
      ...options.headers,
    },
    ...options,
  })

  const text = await response.text()
  let body = null
  try {
    body = text ? JSON.parse(text) : null
  } catch {
    body = text
  }

  if (!response.ok) {
    const messages = body?.mensagens || body?.messages
    const message = Array.isArray(messages) ? messages.join(', ') : body?.message || `Erro ${response.status}`
    throw new Error(message)
  }

  return body
}

export const api = {
  cadastrarCliente: (cliente) => request('/api/Cliente', {
    method: 'POST',
    body: JSON.stringify(cliente),
  }),
  buscarClientes: () => request('/api/Cliente'),
  buscarCarteira: (carteiraId) => request(`/api/Carteira/${carteiraId}`),
  depositar: (transacao) => request('/api/Transacao/deposito', {
    method: 'POST',
    body: JSON.stringify(transacao),
  }),
  debitar: (transacao) => request('/api/Transacao/debito', {
    method: 'POST',
    body: JSON.stringify(transacao),
  }),
}

export { API_URL }
