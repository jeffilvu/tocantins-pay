import { useState } from 'react'
import { api, API_URL } from './api'

const initialClient = {
  nomeCompleto: '',
  email: '',
  telefone: '',
  cpf: '',
  dataNascimento: '',
  senha: '',
}

const initialTransaction = {
  carteiraId: '',
  valor: '',
  descricao: '',
}

function App() {
  const [client, setClient] = useState(initialClient)
  const [clients, setClients] = useState([])
  const [transaction, setTransaction] = useState(initialTransaction)
  const [loading, setLoading] = useState(false)
  const [feedback, setFeedback] = useState(null)

  function updateClient(event) {
    setClient({ ...client, [event.target.name]: event.target.value })
  }

  function updateTransaction(event) {
    setTransaction({ ...transaction, [event.target.name]: event.target.value })
  }

  async function handleClientSubmit(event) {
    event.preventDefault()
    setLoading(true)
    setFeedback(null)
    try {
      const id = await api.cadastrarCliente(client)
      setClient(initialClient)
      setFeedback({ type: 'success', text: `Cliente cadastrado com sucesso. ID: ${id}` })
      await loadClients()
    } catch (error) {
      setFeedback({ type: 'error', text: error.message })
    } finally {
      setLoading(false)
    }
  }

  function selectWallet(walletId) {
    setTransaction((currentTransaction) => ({
      ...currentTransaction,
      carteiraId: walletId,
    }))
    setFeedback({ type: 'success', text: 'Carteira selecionada para a próxima operação.' })
    window.scrollTo({ top: 0, behavior: 'smooth' })
  }

  async function loadClients() {
    try {
      setClients(await api.buscarClientes())
    } catch (error) {
      setFeedback({ type: 'error', text: error.message })
    }
  }

  async function handleTransaction(type) {
    if (!transaction.carteiraId || !transaction.valor || !transaction.descricao) {
      setFeedback({ type: 'error', text: 'Preencha carteira, valor e descrição.' })
      return
    }

    setLoading(true)
    setFeedback(null)
    try {
      const payload = {
        carteiraId: transaction.carteiraId,
        valor: Number(transaction.valor),
        descricao: transaction.descricao,
      }
      const result = type === 'deposito'
        ? await api.depositar(payload)
        : await api.debitar(payload)
      setTransaction(initialTransaction)
      setFeedback({ type: 'success', text: `${type === 'deposito' ? 'Depósito' : 'Débito'} realizado. Saldo resultante: ${result}` })
    } catch (error) {
      setFeedback({ type: 'error', text: error.message })
    } finally {
      setLoading(false)
    }
  }

  return (
    <main className="page-shell">
      <header className="hero">
        <div>
          <span className="eyebrow">TOCANTINS PAY</span>
          <h1>Controle financeiro simples e seguro.</h1>
          <p>Cadastre clientes e teste as operações da API em uma interface única.</p>
        </div>
        <a className="swagger-link" href={`${API_URL}/swagger`} target="_blank" rel="noreferrer">
          Abrir Swagger ↗
        </a>
      </header>

      {feedback && <div className={`feedback ${feedback.type}`}>{feedback.text}</div>}

      <section className="grid-layout">
        <article className="card form-card">
          <div className="card-heading">
            <div><span className="section-label">01</span><h2>Novo cliente</h2></div>
            <span className="badge">POST</span>
          </div>
          <form onSubmit={handleClientSubmit}>
            <label>Nome completo<input name="nomeCompleto" value={client.nomeCompleto} onChange={updateClient} required /></label>
            <div className="two-columns">
              <label>E-mail<input type="email" name="email" value={client.email} onChange={updateClient} required /></label>
              <label>Telefone<input name="telefone" value={client.telefone} onChange={updateClient} required /></label>
            </div>
            <div className="two-columns">
              <label>CPF<input name="cpf" placeholder="529.982.247-25" value={client.cpf} onChange={updateClient} required /></label>
              <label>Data de nascimento<input type="date" name="dataNascimento" value={client.dataNascimento} onChange={updateClient} required /></label>
            </div>
            <label>Senha<input type="password" name="senha" value={client.senha} onChange={updateClient} required /></label>
            <button type="submit" disabled={loading}>{loading ? 'Enviando...' : 'Cadastrar cliente'}</button>
          </form>
        </article>

        <article className="card form-card">
          <div className="card-heading">
            <div><span className="section-label">02</span><h2>Movimentar carteira</h2></div>
            <span className="badge secondary">POST</span>
          </div>
          <p className="helper">O cadastro cria uma carteira. Informe o <strong>carteiraId</strong> retornado ou consultado no banco.</p>
          <form onSubmit={(event) => event.preventDefault()}>
            <label>ID da carteira<input name="carteiraId" value={transaction.carteiraId} onChange={updateTransaction} placeholder="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" required /></label>
            <div className="two-columns">
              <label>Valor<input type="number" min="0.01" step="0.01" name="valor" value={transaction.valor} onChange={updateTransaction} required /></label>
              <label>Descrição<input name="descricao" value={transaction.descricao} onChange={updateTransaction} required /></label>
            </div>
            <div className="button-row">
              <button type="button" onClick={() => handleTransaction('deposito')} disabled={loading}>Depositar</button>
              <button type="button" className="outline" onClick={() => handleTransaction('debito')} disabled={loading}>Debitar</button>
            </div>
          </form>
        </article>
      </section>

      <section className="card clients-card">
        <div className="card-heading">
          <div><span className="section-label">03</span><h2>Clientes cadastrados</h2></div>
          <button type="button" className="outline compact" onClick={loadClients} disabled={loading}>Atualizar lista</button>
        </div>
        {clients.length === 0 ? <p className="empty">Clique em “Atualizar lista” para consultar os clientes cadastrados.</p> : (
          <div className="table-wrap"><table><thead><tr><th>Nome</th><th>Data de nascimento</th><th>ID do cliente</th><th>ID da carteira</th><th></th></tr></thead><tbody>
            {clients.map((item) => <tr key={item.id}><td>{item.nomeCompleto}</td><td>{item.dataNascimento}</td><td className="id-cell">{item.id}</td><td className="id-cell">{item.carteiraId}</td><td><button type="button" className="outline compact" onClick={() => selectWallet(item.carteiraId)}>Usar carteira</button></td></tr>)}
          </tbody></table></div>
        )}
      </section>
    </main>
  )
}

export default App
