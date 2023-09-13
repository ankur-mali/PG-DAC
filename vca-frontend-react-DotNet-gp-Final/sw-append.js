const fs = require('fs');
const path = require('path');

const filePathToRead = path.join(__dirname, 'build', 'asset-manifest.json');
const filePathToAppend = path.join(__dirname, 'build', 'serviceWorkerProd.js');

fs.readFile(filePathToRead, 'utf8', (err, data) => {
  if (err) {
    console.error('Error reading JSON file:', err);
    return;
  }

  try {
    const jsonData = JSON.parse(data);
    const filesArray = Object.values(jsonData.files);

    // Convert array into string
    const filesArrayObj = `const array = ${JSON.stringify(filesArray)};`;

    // Read the existing content of the file to append to
    fs.readFile(filePathToAppend, 'utf8', (err, fileContent) => {
      if (err) {
        console.error('Error reading file to append to:', err);
        return;
      }

      // Prepend the generated data to the existing content
      const updatedContent = filesArrayObj + '\n' + fileContent;

      // Write the updated content back to the file
      fs.writeFile(filePathToAppend, updatedContent, 'utf8', (err) => {
        if (err) {
          console.error('Error appending data to file:', err);
        } else {
          console.log('Data appended successfully!');
        }
      });

    });
  } catch (err) {
    console.error('Error parsing JSON:', err);
  }
});
