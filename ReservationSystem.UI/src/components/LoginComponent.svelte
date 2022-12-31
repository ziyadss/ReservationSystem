<script>
    import { prevent_default } from 'svelte/internal';
    import { store } from '../hooks/auth.js';

    let username = '';
    let password = '';

    async function login() {
        const response = await fetch('/api/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                username,
                password
            })
        });
        console.log(response);
        console.log(username);
        console.log(password);


        if (response.ok) {
            const { user } = await response.json();
            store.set(user);
        }
        else {
            alert('Invalid credentials');
        }
    }
</script>


<form on:submit|preventDefault={login} class="login-form flex mx-auto col-6">
    <div class="form-control">
        <label for="username">Username</label>
        <input type="text" id="username" bind:value={username} />
    </div>
    <div class="form-control">
        <label for="password">Password</label>
        <input type="password" id="password" bind:value={password} />
    </div>
    <button type="submit" class="btn-primary">Login</button>
</form>