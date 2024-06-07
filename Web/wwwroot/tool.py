import csv
import requests
import os
from urllib.parse import urlparse

# Đọc file CSV
with open('product.csv', 'r') as file:
    reader = csv.reader(file)
    next(reader)  # Bỏ qua hàng tiêu đề
    i = 0
    for row in reader:
        i += 1
        url = 'https://' + row[0]  # Giả sử đường dẫn ảnh nằm ở cột đầu tiên

        # Tải ảnh
        response = requests.get(url, stream=True)
        response.raise_for_status()

        # Lấy tên ảnh từ đường dẫn
        a = urlparse(url)
        filename = os.path.basename(a.path)

        # Tạo thư mục nếu chưa tồn tại
        directory = os.path.join('Upload', 'Images')
        if not os.path.exists(directory):
            os.makedirs(directory)

        # Lưu ảnh vào thư mục Upload/Images
        with open(os.path.join(directory, filename), 'wb') as out_file:
            out_file.write(response.content)
        
        # In ra câu lệnh SQL
        
        print(f"WHEN id = {i} THEN 'Upload/Images/{filename}'")