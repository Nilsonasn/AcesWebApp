function GETOauthGithub() {
    window.alert("Alright chums lets do this.");
    $.get({
        url:"https://github.com/login/oauth/authorize",
        client_id:"b8adc9fb66220497bc65",
        redirect_uri:"https://localhost:44317/Assignments"
    });
}