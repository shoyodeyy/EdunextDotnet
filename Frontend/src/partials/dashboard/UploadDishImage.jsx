import React, { useRef, useState } from "react";
import { useDish } from "../../hooks/useDish";

const UploadDishImage = () => {
  const { dishes, updateDish } = useDish();

  const [selectedId, setSelectedId] = useState("");
  const [uploading, setUploading] = useState(false);
  const [showCamera, setShowCamera] = useState(false);

  const fileInputRef = useRef(null);
  const videoRef = useRef(null);
  const canvasRef = useRef(null);

  const handleUploadClick = () => {
    if (!selectedId) {
      alert("Please select a dish first");
      return;
    }
    fileInputRef.current.click();
  };

  const handleFileChange = (e) => {
    const file = e.target.files[0];
    if (file && selectedId) {
      processImage(file);
    }
  };

  const processImage = (fileOrData) => {
    setUploading(true);

    if (typeof fileOrData === "string") {
      setTimeout(() => {
        updateDish(selectedId, { image: fileOrData });
        finish();
      }, 800);
      return;
    }

    const reader = new FileReader();
    reader.onloadend = () => {
      setTimeout(() => {
        updateDish(selectedId, { image: reader.result });
        finish();
      }, 800);
    };
    reader.readAsDataURL(fileOrData);
  };

  const finish = () => {
    setUploading(false);
    setSelectedId("");
    setShowCamera(false);
    if (fileInputRef.current) fileInputRef.current.value = "";
  };

  const startCamera = async () => {
    if (!selectedId) {
      alert("Please select a dish first");
      return;
    }

    try {
      setShowCamera(true);
      const stream = await navigator.mediaDevices.getUserMedia({
        video: { facingMode: "environment" },
      });
      videoRef.current.srcObject = stream;
    } catch {
      alert("Camera failed");
      setShowCamera(false);
    }
  };

  const capturePhoto = () => {
    const video = videoRef.current;
    const canvas = canvasRef.current;

    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;

    const ctx = canvas.getContext("2d");
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);

    const dataUrl = canvas.toDataURL("image/jpeg");

    video.srcObject.getTracks().forEach((t) => t.stop());
    processImage(dataUrl);
  };

  const closeCamera = () => {
    if (videoRef.current?.srcObject) {
      videoRef.current.srcObject.getTracks().forEach((t) => t.stop());
    }
    setShowCamera(false);
  };

  return (
    <div className="flex flex-col col-span-full sm:col-span-6 bg-white dark:bg-gray-800 shadow-xs rounded-xl">
      {/* Header */}
      <header className="px-5 py-4 border-b border-gray-100 dark:border-gray-700/60">
        <h2 className="font-semibold text-gray-800 dark:text-gray-100">Dish Visuals</h2>
        <p className="text-gray-500 dark:text-gray-400 text-sm">Upload or capture dish images</p>
      </header>

      {/* Body */}
      <div className="p-5 flex flex-col gap-4">
        {/* Select Dish */}
        <select
          value={selectedId}
          onChange={(e) => setSelectedId(e.target.value)}
          className="px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-gray-200 focus:outline-none focus:ring-2 focus:ring-sky-500"
        >
          <option value="">Choose dish...</option>
          {dishes.map((d) => (
            <option key={d.id} value={d.id}>{d.name}</option>
          ))}
        </select>

        {!showCamera ? (
          <div className="flex flex-col sm:flex-row gap-2">
            <button
              onClick={handleUploadClick}
              disabled={!selectedId || uploading}
              className="flex-1 py-2 px-4 bg-sky-500 hover:bg-sky-600 text-white rounded-md shadow text-sm font-medium disabled:opacity-50"
            >
              Upload Image
            </button>

            <button
              onClick={startCamera}
              disabled={!selectedId || uploading}
              className="flex-1 py-2 px-4 bg-gray-200 dark:bg-gray-700 text-gray-900 dark:text-gray-200 rounded-md shadow text-sm font-medium hover:bg-gray-300 dark:hover:bg-gray-600 disabled:opacity-50"
            >
              Use Camera
            </button>
          </div>
        ) : (
          <div className="flex flex-col items-center gap-2">
            <video ref={videoRef} autoPlay playsInline className="rounded-md w-full max-w-md" />
            <canvas ref={canvasRef} hidden />
            <div className="flex gap-2 mt-2">
              <button
                onClick={capturePhoto}
                className="py-2 px-4 bg-green-500 hover:bg-green-600 text-white rounded-md"
              >
                📸 Capture
              </button>
              <button
                onClick={closeCamera}
                className="py-2 px-4 bg-red-500 hover:bg-red-600 text-white rounded-md"
              >
                ✕ Close
              </button>
            </div>
          </div>
        )}

        <input
          ref={fileInputRef}
          type="file"
          accept="image/*"
          hidden
          onChange={handleFileChange}
        />

        {uploading && (
          <p className="text-center text-gray-500 dark:text-gray-400 font-medium">Processing image...</p>
        )}
      </div>
    </div>
  );
};

export default UploadDishImage;
