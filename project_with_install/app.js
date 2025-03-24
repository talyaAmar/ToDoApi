import express from 'express';
import renderApi from '@api/render-api';

const app = express();

app.get('/', async (req, res) => {
    try {
        renderApi.auth('rnd_LlqYg9xFuF6jYxYbxO2dfNNYRJlH'); 
        const { data } = await renderApi.listServices({ includePreviews: 'true' });
        res.json(data);
    } catch (err) {
        console.error(err);
        res.status(500).json({ error: 'שגיאה פנימית בשרת' });
    }
});

const port = process.env.PORT || 3000;
app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});